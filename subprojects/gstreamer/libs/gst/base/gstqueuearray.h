/* GStreamer
 * Copyright (C) 2009-2010 Edward Hervey <bilboed@bilboed.com>
 *
 * gstqueuearray.h:
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Library General Public
 * License as published by the Free Software Foundation; either
 * version 2 of the License, or (at your option) any later version.
 *
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Library General Public License for more details.
 *
 * You should have received a copy of the GNU Library General Public
 * License along with this library; if not, write to the
 * Free Software Foundation, Inc., 51 Franklin St, Fifth Floor,
 * Boston, MA 02110-1301, USA.
 */

#include <glib.h>

#ifndef __GST_QUEUE_ARRAY_H__
#define __GST_QUEUE_ARRAY_H__

#include <gst/base/base-prelude.h>

G_BEGIN_DECLS

/**
 * GstQueueArray: (skip)
 */
typedef struct _GstQueueArray GstQueueArray;

/**
 * gst_queue_array_new 和 gst_queue_array_new_for_struct 区别是：
 * struct会开辟内存存储数据，非struct只是存储地址。
 */
GST_BASE_API
GstQueueArray * gst_queue_array_new       (guint initial_size);

GST_BASE_API
void            gst_queue_array_free      (GstQueueArray * array);

GST_BASE_API
void            gst_queue_array_set_clear_func (GstQueueArray *array,
                                                GDestroyNotify clear_func);

GST_BASE_API
void            gst_queue_array_clear     (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_pop_head  (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_head (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_nth  (GstQueueArray * array, guint idx);

GST_BASE_API
gpointer        gst_queue_array_pop_tail  (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_tail (GstQueueArray * array);

GST_BASE_API
void            gst_queue_array_push_tail (GstQueueArray * array,
                                           gpointer        data);
GST_BASE_API
gboolean        gst_queue_array_is_empty  (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_drop_element (GstQueueArray * array,
                                              guint           idx);
GST_BASE_API
guint           gst_queue_array_find (GstQueueArray * array,
                                      GCompareFunc    func,
                                      gpointer        data);
GST_BASE_API
guint           gst_queue_array_get_length (GstQueueArray * array);

/* Functions for use with structures */
/**
 * @struct_size: 数组中每个元素占用多少字节的内存（比如存储的是某个结构体， struct_size = sizeof(structure）
 * @initial_size: 初始预分配多少个元素（只是预分配，还没有使用）
 */
GST_BASE_API
GstQueueArray * gst_queue_array_new_for_struct (gsize struct_size,
                                                guint initial_size);
GST_BASE_API
void            gst_queue_array_push_tail_struct (GstQueueArray * array,
                                                  gpointer        p_struct);
GST_BASE_API
gpointer        gst_queue_array_pop_head_struct  (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_head_struct (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_nth_struct  (GstQueueArray * array, guint idx);

GST_BASE_API
gboolean        gst_queue_array_drop_struct      (GstQueueArray * array,
                                                  guint           idx,
                                                  gpointer        p_struct);
GST_BASE_API
gpointer        gst_queue_array_pop_tail_struct  (GstQueueArray * array);

GST_BASE_API
gpointer        gst_queue_array_peek_tail_struct (GstQueueArray * array);

G_END_DECLS

#endif
